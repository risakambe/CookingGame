using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class FoodManager : MonoBehaviour
{
    private List<string> ingredients = new List<string> (){
        "Salt","Pepper","Sugar","PotatoStarch","ChickenStockPowder","SoySauce",
        "ChineseChiliBeanSauce","SesameOil","Milk",
        "Water","Cabbage","ChineseCabbage","Carrot","Onion","Radish","GreenOnion",
        "Egg","Tofu","Potato","Pampkin","Cucumber","Pork","Beef","Chicken",
        "GroundBeef","GroundPork","Eggplant","BellPepper","Shrimp","Ginger","Rice"
    };

    private List<string> ans0 = new List<string> (){
        "Salt","Pepper","Egg","Chicken","Potato"
    };
    private List<string> ans1 = new List<string> (){
        "Salt","Pepper","Egg","Chicken","Potato"
    };

    private List<int> scenes0 = new List<int>(){6,7,8,9,14};
    private List<int> scenes1 = new List<int>(){10,11,12,13,14};
    
    private List<string> dish_name_list = new List<string>(){"hogehoge1", "hogehoge2"};
    private List<List<string>> ingredients_ans_list = new List<List<string>>();
    private List<List<int>> scenes_list = new List<List<int>>();

    void Awake()
    {
        ingredients_ans_list.Add(ans0);
        ingredients_ans_list.Add(ans1);
        scenes_list.Add(scenes0);
        scenes_list.Add(scenes1);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public List<string> GetAllIngredients(){
        return ingredients;
    }

    public string GetDishName (int dish_idx){
        return dish_name_list[dish_idx];
    }

    public List<string> GetIngredientsAns(int dish_idx){
       return ingredients_ans_list[dish_idx];
    }

    public List<int> GetSceneList(int dish_idx){
        return scenes_list[dish_idx];
    }
}
