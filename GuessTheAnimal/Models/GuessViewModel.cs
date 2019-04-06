using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuessTheAnimal.Models
{
  public class GuessViewModel
  {
    public Dictionary<string, string> previousAnswers = new Dictionary<string, string>();
    public string GuessAnimal;
    public string Correct = "";
  }
}