using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Dojodochi.Models;
namespace Dojodochi.Controllers

{
    public class DojoController : Controller
    {
        [HttpGet("")]
        public IActionResult Index(Life Dochi)
        {
                if(HttpContext.Session.GetInt32("HappyCount") == null)
                {
                    Dochi = new Life();
                    HttpContext.Session.SetInt32("HappyCount", 20);
                    HttpContext.Session.SetInt32("FullCount", 20);
                    HttpContext.Session.SetInt32("EnergyCount", 50);
                    HttpContext.Session.SetInt32("MealCount", 3);
                    HttpContext.Session.SetString("ReadComment", "");
                    return View(Dochi);
                }
                else
                {
                    Dochi.happiness = (int)HttpContext.Session.GetInt32("HappyCount");
                    Dochi.fullness = (int)HttpContext.Session.GetInt32("FullCount");
                    Dochi.energy = (int)HttpContext.Session.GetInt32("EnergyCount");
                    Dochi.meals = (int)HttpContext.Session.GetInt32("MealCount");
                    Dochi.comment = HttpContext.Session.GetString("ReadComment");
                    return View(Dochi);
                }
            
        }
                [HttpGet("feed")]
                    public IActionResult Feed()
                    {
                        int? NumMeals = HttpContext.Session.GetInt32("MealCount");
                        if( NumMeals == 0)
                        {
                            HttpContext.Session.SetString("ReadComment", "Sorry all out of meal");
                            return RedirectToAction("Index");

                        }
                        NumMeals --;
                        HttpContext.Session.SetInt32("MealCount", (int)NumMeals);
                        Random random = new Random();
                        int snack = random.Next(4);
                        if(snack == 1)
                        {
                            HttpContext.Session.SetString("ReadComment", "I Fucking hated it, Yuck you lose a meal haha!");
                        }
                        else
                        {
                        int eat = random.Next(5, 11);
                        int? HowFull = HttpContext.Session.GetInt32("FullCount");
                        HowFull += eat;
                        HttpContext.Session.SetInt32("FullCount", (int)HowFull);
                        HttpContext.Session.SetString("ReadComment", "You have fed your Dochi!");
                        }

                        return RedirectToAction("Index");
                    }
            

                    [HttpGet("play")]
                public IActionResult Play()
                {
                    int? Motivation = HttpContext.Session.GetInt32("EnergyCount");
                    if( Motivation == 0)
                    {
                        HttpContext.Session.SetString("ReadComment", "Im too tired to play");
                        return RedirectToAction("Index");

                    }
                    Motivation -=5;
                    HttpContext.Session.SetInt32("EnergyCount", (int)Motivation);
                    Random random = new Random();
                    int attitude = random.Next(4);
                    if(attitude == 1)
                    {
                        HttpContext.Session.SetString("ReadComment", "I hate you so much right now!");
                    }
                    else
                    {
                    int fun = random.Next(5, 11);
                    int? HowHappy = HttpContext.Session.GetInt32("HappyCount");
                    HowHappy += fun;
                    HttpContext.Session.SetInt32("HappyCount", (int)HowHappy);
                    HttpContext.Session.SetString("ReadComment", "AGAIN AGAIN!!!!");
                    }
                    return RedirectToAction("Index");
                }
                    [HttpGet("work")]
                    public IActionResult Work()
                    {
                            int? Stamina = HttpContext.Session.GetInt32("EnergyCount");
                            if( Stamina == 0)
                        {
                            HttpContext.Session.SetString("ReadComment", "Im too tired to Work");
                            return RedirectToAction("Index");

                        }
                        
                        else
                        {
                            Random random = new Random();
                            int job = random.Next(1,4);
                            int? NumMeals = HttpContext.Session.GetInt32("MealCount");
                            NumMeals += job;
                            HttpContext.Session.SetInt32("MealCount", (int)NumMeals);
                            HttpContext.Session.SetString("ReadComment", "Lets get to work!");
                        }
                        return RedirectToAction("Index");
                    }
                    [HttpGet("sleep")]
                    public IActionResult Sleep()
                    {
                        int? Motivation = HttpContext.Session.GetInt32("EnergyCount");
                        Motivation += 15;
                        // HttpContext.Session.SetString("ReadComment", "You got some Enery during your nap lets do something");
                        int? Belly = HttpContext.Session.GetInt32("FullCount");
                        Belly -= 5;
                        // HttpContext.Session.SetString("ReadComment", "You got some Enery during your nap but you could use a snack");
                        int? Mood = HttpContext.Session.GetInt32("HappyCount");
                        Mood -= 5; 
                        HttpContext.Session.SetInt32("EnergyCount", (int)Motivation);
                        HttpContext.Session.SetInt32("FullCount", (int)Belly);
                        HttpContext.Session.SetInt32("HappyCount", (int)Mood);
                        {
                        HttpContext.Session.SetString("ReadComment", "I got some Enery during my nap I wanna play..... Or do I?");
                        return RedirectToAction("Index");
                        }

                    }
                    [HttpGet("loser")]
                    public IActionResult Lose(Life Dochi)
                    {
                        if(Dochi.happiness == 0 || Dochi.fullness == 0)
                        {
                            HttpContext.Session.SetString("ReadComment", "Your name must be curiosity because you killed the cat");
                            return View("loser");
                        }
                        return View("");
                        
                    }
                    [HttpGet("winner")]
                    public IActionResult Win(Life Dochi)
                    {
                        if(Dochi.happiness >=100 && Dochi.fullness >= 100 && Dochi.energy >= 100)
                        {
                            HttpContext.Session.SetString("ReadComment", "You Win!!!!");
                            return View("winner");
                        }
                        return View("");
                    }
              }
    
}