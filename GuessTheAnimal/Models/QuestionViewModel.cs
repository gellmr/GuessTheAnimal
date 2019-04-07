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
  }

  public class TextQuestionViewModel : QuestionViewModel
  {
    [Required]
    public string Answer = "";
  }

  public class NumericQuestionViewModel : QuestionViewModel
  {
    [Required]
    public int? Answer = null;
  }
}