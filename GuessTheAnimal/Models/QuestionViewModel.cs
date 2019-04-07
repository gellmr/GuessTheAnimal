using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GuessTheAnimal.Models
{
  public class QuestionViewModel
  {
    public Dictionary<string, string> previousAnswers = null;
    public bool FirstQuestion = false;
    public string QuestionText = "";
    public string NextQuestion = "";

    [Required]
    public string Answer = "";
  }
}