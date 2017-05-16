using System;
using System.Web;
using Portfolio.Models;

namespace Portfolio.Data {

    public class TasksRepository {

        static ProjectTask[] _tasks = new ProjectTask[] {
            new ProjectTask() {
                Id = 1,
                Name = "Kalkulator Walutowy",
                Description = "Program umożliwiający przeliczanie wartości walut. " +
                              "Wybranie określonej waluty oraz wpisanie wartości (wsparcie dla dużych wartości) " +
                              "jest możliwe w wybranej przez użytkownika dacie. Program w czytelny, praktyczny " +
                              "dla użytkownika sposób wypisuje wartość gotówki przeliczoną po przeprowadzonej operacji.",
                TechnologiesUsed = new technology[] { technology.cpp, technology.objectiveprogramming },
                EndDate = new DateTime(2015, 1, 10),
                ImgAmount = 5
            },
            new ProjectTask() {
                Id = 2,
                Name = "Witryna internetowa",
                Description = "Strona internetowa spełniająca rolę reklamy internetowej firmy ubezpieczeniowej.",
                TechnologiesUsed = new technology[] { technology.html, technology.css, technology.javascript,
                                                      technology.jquery},
                Commercial = true,
                EndDate = new DateTime(2014, 8, 10),
                ImgAmount = 4
            },
            new ProjectTask() {
                Id = 3,
                Name = "Strona internetowa",
                Description = "Przedstawienie oferty firmy gastronomicznej oraz składanie zamówień. ",
                TechnologiesUsed = new technology[] {technology.html, technology.css},
                Commercial = true,
                EndDate = new DateTime(2014, 9, 10),
                ImgAmount = 2
            },
            new ProjectTask() {
                Id = 4,
                Name = "Planowanie zakupów",
                Description = "System sprzedaży określający liste zakupów wyznaczonych produktów. " +
                              "Aplikacja oblicza koszt zakupów wybranych z listy, mając na uwadze " +
                              "wyznaczoną sumę gotówki.",
                TechnologiesUsed = new technology[] { technology.csharp },
                EndDate = new DateTime(2015, 6, 10),
                ImgAmount = 3
            },
            new ProjectTask() {
                Id = 5,
                Name = "Program tv",
                Description = "Spis programów telewizyjnych na wybranych stacjach tv. " +
                              "Aplikacja pobiera dane ze strony internetowej tworząc godzinową rozpiskę programów. " +
                              "Baza danych kanałów oraz dat jest aktualizowana podczas działania programu.",
                TechnologiesUsed = new technology[] {technology.java},
                EndDate = new DateTime(2015, 4, 5),
                ImgAmount = 6
            }

        };

        public ProjectTask[] Tasks { get{ return _tasks; } }

        public ProjectTask GetTask(int id) {
            foreach (var task in _tasks) {
                if (task.Id == id)
                    return task;
            }
            return null;
        }

    }
}
