using APICardLab.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using APICardLab.Models;
using Unit_7_Deck_Of_Cards_API_Lab.Models;

namespace APICardLab
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DeckDAL deckAPI = new DeckDAL();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Deck deck = deckAPI.NewDeck();
            List<Card> drawnCards = deckAPI.DrawCard(deck.deck_id).cards.ToList();
            return View(drawnCards);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}