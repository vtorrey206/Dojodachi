using System;
using System.ComponentModel.DataAnnotations;
namespace Dojodochi.Models

{
    public class Life
    {
        public int happiness {get;set;}
        public int fullness {get;set;}
        public int energy {get;set;}
        public int meals {get;set;}
        // public string dochi {get;set;}
        public string comment {get;set;}
    
        public Life()
        {
            
            happiness = 20;
            fullness = 20;
            energy = 50;
            meals = 3;
        }
    }

    

}