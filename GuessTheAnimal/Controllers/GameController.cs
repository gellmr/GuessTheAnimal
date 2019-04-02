using GuessTheAnimal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuessTheAnimal.Controllers
{
  public class GameController : Controller
  {

    public Dictionary<string, string> GetSessionAnswers()
    {
      if (Session["Answers"] == null)
      {
        Session["Answers"] = new Dictionary<string, string>();
      }
      Dictionary<string, string> answers = (Dictionary<string, string>)Session["Answers"];
      return answers;
    }
    public void SaveSessionAnswers(Dictionary<string, string> answers)
    {
      Session["Answers"] = answers;
    }

    public ActionResult Question1()
    {
      Dictionary<string, string> answers = GetSessionAnswers();
      answers.Clear();
      SaveSessionAnswers(answers);
      QuestionViewModel model = new QuestionViewModel();
      model.FirstQuestion = true;
      model.QuestionText = "How many legs does the animal have?";
      model.NextQuestion = "Question2";
      return View("TextQuestion", model);
    }
    
    [HttpPost]
    public ActionResult Question2(string QuestionText, string Answer)
    {
      Dictionary<string, string> answers = GetSessionAnswers();
      answers.Add(QuestionText, Answer);
      SaveSessionAnswers(answers);
      QuestionViewModel model = new QuestionViewModel();
      model.QuestionText = "Does it have stripes?";
      model.NextQuestion = "Question3";
      return View("TextQuestion", model);
    }

    [HttpPost]
    public ActionResult Question3(string QuestionText, string Answer)
    {
      Dictionary<string, string> answers = GetSessionAnswers();
      answers.Add(QuestionText, Answer);
      SaveSessionAnswers(answers);
      QuestionViewModel model = new QuestionViewModel();
      model.QuestionText = "Does it swim?";
      model.NextQuestion = "Question4";
      return View("TextQuestion", model);
    }

    [HttpPost]
    public ActionResult Question4(string QuestionText, string Answer)
    {
      Dictionary<string, string> answers = GetSessionAnswers();
      answers.Add(QuestionText, Answer);
      SaveSessionAnswers(answers);
      QuestionViewModel model = new QuestionViewModel();
      model.QuestionText = "What color is the animal?";
      model.NextQuestion = "Question5";
      return View("TextQuestion", model);
    }

    [HttpPost]
    public ActionResult Question5(string QuestionText, string Answer)
    {
      Dictionary<string, string> answers = GetSessionAnswers();
      answers.Add(QuestionText, Answer);
      SaveSessionAnswers(answers);
      QuestionViewModel model = new QuestionViewModel();
      model.QuestionText = "Can it fly?";
      model.NextQuestion = "End";
      return View("TextQuestion", model);
    }

    [HttpPost]
    public ActionResult End(string QuestionText, string Answer)
    {
      Dictionary<string, string> answers = GetSessionAnswers();
      answers.Add(QuestionText, Answer);
      SaveSessionAnswers(answers);
      QuestionViewModel model = new QuestionViewModel();
      return View("Guess", model);
    }

    public ActionResult Correct()
    {
      return View();
    }

    public ActionResult Wrong()
    {
      return View();
    }
  }
}