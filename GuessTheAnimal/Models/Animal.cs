using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace GuessTheAnimal.Models
{
  public class Animal
  {
    public int Id;
    public string Name;
    public int Legs;
    public bool Stripes;
    public bool Swim;
    public string Color;
    public bool Fly;
    public bool Fast;
  }
  
}