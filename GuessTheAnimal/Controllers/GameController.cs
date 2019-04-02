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
    //public List<Animal> Animals;

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
      if (answers.ContainsKey(QuestionText)) { answers.Remove(QuestionText); } // overwrite previous answer is user navigates backward thru the quiz.
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
      if (answers.ContainsKey(QuestionText)) { answers.Remove(QuestionText); } // overwrite previous answer is user navigates backward thru the quiz.
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
      if (answers.ContainsKey(QuestionText)) { answers.Remove(QuestionText); } // overwrite previous answer is user navigates backward thru the quiz.
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
      if (answers.ContainsKey(QuestionText)) { answers.Remove(QuestionText); } // overwrite previous answer is user navigates backward thru the quiz.
      answers.Add(QuestionText, Answer);
      SaveSessionAnswers(answers);
      QuestionViewModel model = new QuestionViewModel();
      model.QuestionText = "Can it fly?";
      model.NextQuestion = "End";
      return View("TextQuestion", model);
    }

    // Convert "yes" into bool true and "no" into bool false.
    private bool YesNo(string str)
    {
      if (str.ToLower().Equals("yes")) { return true; }
      if (str.ToLower().Equals("true")) { return true; }

      if (str.ToLower().Equals("no")) { return false; }
      if (str.ToLower().Equals("false")) { return false; }

      return false;
    }

    [HttpPost]
    public ActionResult End(string QuestionText, string Answer)
    {
      Dictionary<string, string> answers = GetSessionAnswers();
      if (answers.ContainsKey(QuestionText)) { answers.Remove(QuestionText); } // overwrite previous answer is user navigates backward thru the quiz.
      answers.Add(QuestionText, Answer);
      SaveSessionAnswers(answers);

      List<Animal> animals = GetSessionAnimals();
      IEnumerable<Animal> animalSet = animals.Where(a =>
        a.Legs == int.Parse(answers["How many legs does the animal have?"])
        &&
        a.Stripes == YesNo(answers["Does it have stripes?"])
        &&
        a.Swim == YesNo(answers["Does it swim?"])
        &&
        a.Color == answers["What color is the animal?"]
        &&
        a.Fly == YesNo(answers["Can it fly?"])
      );

      List<Animal> result = animalSet.ToList();

      if (result.Count == 0)
      {
        return View("Wrong");
      }
      
      GuessViewModel model = new GuessViewModel();
      model.GuessAnimal = result.First().Name;
      return View("Guess", model);
    }

    public ActionResult Correct()
    {
      return View();
    }

    public ActionResult Wrong()
    {
      UpdateAnimals model = new UpdateAnimals();
      model.NewAnimal = "";
      return View();
    }

    // Remember the animal so we can guess it in the future.
    public ActionResult UpdateAnimals(string NewAnimal)
    {
      Dictionary<string, string> answers = GetSessionAnswers();
      List<Animal> animals = GetSessionAnimals();
      Animal animal = new Animal
      {
        Name = NewAnimal,
        Legs = int.Parse(answers["How many legs does the animal have?"]),
        Stripes = YesNo(answers["Does it have stripes?"]),
        Swim = YesNo(answers["Does it swim?"]),
        Color = answers["What color is the animal?"],
        Fly = YesNo(answers["Can it fly?"])
      };
      if (answers.ContainsKey(NewAnimal)) { answers.Remove(NewAnimal); } // avoid duplicates.
      animals.Add(animal);
      SaveSessionAnimals(animals);
      return View("Correct");
    }


    // Todo: use localdb for persistence.

    public List<Animal> GetSessionAnimals()
    {
      if (Session["Animals"] == null) { Session["Animals"] = InitAnimals(); }
      return (List<Animal>)Session["Animals"];
    }
    public void SaveSessionAnimals(List<Animal> animals)
    {
      Session["Animals"] = animals;
    }

    private List<Animal> InitAnimals()
    {
      // TODO: use localdb and seed data

      List<Animal> animals = new List<Animal>();
      animals.Add(new Animal {
        Name = "Hippapotamus",
        Fly = false,
        Fast = false,
        Legs = 4,
        Stripes = false,
        Swim = true,
        Color = "grey"
      });

      animals.Add(new Animal
      {
        Name = "Fish",
        Fly = false,
        Fast = true,
        Legs = 0,
        Stripes = false,
        Swim = true,
        Color = "grey"
      });
      return animals;
    }
  }
}