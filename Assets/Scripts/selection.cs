using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;


public class selection : MonoBehaviourPunCallbacks
{
    int finalscores;
    private  EventSystem eventSystem;
    private List<string> ingredients = new List<string> (){
        "Salt","Pepper","Sugar","PotatoStarch","ChickenStockPowder","SoySauce",
        "ChineseChiliBeanSauce","SesameOil","Milk",
        "Water","Cabbage","ChineseCabbage","Carrot","Onion","Radish","GreenOnion",
        "Egg","Tofu","Potato","Pampkin","Cucumber","Pork","Beef","Chicken",
        "GroundBeef","GroundPork","Eggplant","BellPepper","Shrimp","Ginger","Rice"
    };
    private List<string> ingredients_ans = new List<string> (){
        "Salt","Pepper",
        "Egg","Chicken","Potato"
    };
    public Dictionary<string,bool> ingredients_activation = new Dictionary<string,bool>();
    public List<Button> ingredient_buttons = new List<Button> ();

    // Start is called before the first frame update
    void Awake(){
        PhotonNetwork.AutomaticallySyncScene = false;
        eventSystem=EventSystem.current;
    }
    void Start()
    { 
        Button enter_button = this.transform.Find("EnterButton").gameObject.GetComponent<Button>();
        enter_button.onClick.AddListener(Select_enter_clicked); 
        foreach (string ing in ingredients){
            ingredients_activation.Add(ing,false); 
            Button ing_button = this.transform.Find("Scroll View/Viewport/Content/"+ing).gameObject.GetComponent<Button>();
           
            ing_button.onClick.AddListener(Button_clicked); 
            
        }        
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    void Button_clicked(){
        GameObject red_frame= Resources.Load("Prefabs/frame",  typeof(GameObject)) as GameObject;
        GameObject clicked_button = eventSystem.currentSelectedGameObject;
        string clicked_button_name = clicked_button.name;
        if (ingredients_activation[clicked_button_name]==false){
            GameObject instantiated_frame = Instantiate(red_frame,clicked_button.transform.position, Quaternion.identity) as GameObject;
            instantiated_frame.name = "frame";
            instantiated_frame.transform.SetParent(clicked_button.transform);
            instantiated_frame.transform.localScale = Vector3.one*1.2f;
        }
        else{
            Destroy(clicked_button.transform.Find("frame").gameObject);
        }
        ingredients_activation[clicked_button_name] = !ingredients_activation[clicked_button_name];
    }
    void Select_enter_clicked(){ 
        int correct_counter = 0;
        int total_ing_num = ingredients_ans.Count;

        foreach (KeyValuePair<string, bool> item in ingredients_activation)
        {
            if (item.Value == true)
            {
                if (ingredients_ans.Contains(item.Key)) {
                    correct_counter++;
                    Debug.Log("correct:"+correct_counter.ToString());
                }
                else
                {
                    correct_counter--;
                    Debug.Log("wrong:" + correct_counter.ToString());
                }
                
            }
/*            else {
                if (ingredients_ans.Contains(item.Key))
                {
                    correct_counter--;
                    Debug.Log(correct_counter.ToString());
                }
            }*/     
        }

        if (correct_counter < 0) {
            correct_counter = 0;
        }
        PhotonNetwork.LocalPlayer.AddScore(correct_counter);
        Debug.Log(correct_counter);
        //Debug.Log(correct_counter.ToString() + "/"+ total_ing_num.ToString());
        //Debug.Log(PhotonNetwork.LocalPlayer.GetScore().ToString());
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("rankingScene");
        
    }
}
