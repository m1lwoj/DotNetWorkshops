# OOP

## Zadanie 1 - Proceduralna implementacja TaxCalculator

1. Pobierz projekt TaxCalculator 
2. Zmodyfikuj kod` TaxCalculator.Program.CalculateParams` tak aby wszystkie testy z `TaxCalculatorTest.TestTotalPriceCalculation` przeszły pomyślnie

## Zadanie 2 - Obiektowa implementacja TaxCalculator
1. Zmodyfikuj kod z zadania 1, tak aby wykorzystać wszystkie cechy programowania obiektowego.
Uzyj dziedziczenia, polimorfizmu, enkapsulacji i abstrakcji podczas implementacji.
Pamiętaj o poprawnym wyniku testów.

## Zadanie 3 - Obiektowe modelowanie problemu biznesowego
1. Zamodeluj obiektowo w C# grę w statki:
- 2 graczy
- plansza 10x10
- każdy z graczy ma możliwość rozmieszczenia 5 statków (3 o długości 3 pól i 2 o długości 2 pól)
- gra kończy się gdy któryś z graczy trafi wszystkie

Uwaga! Zadanie należy rozpocząć od obiektowego modelowania rozwiązania.

## Zadanie 4 - SOLID
1. Biorąc pod uwagę zasady SOLID zmodyfikuj Zadanie 3, tak aby wszystkie zasady SOLID były spełnione.

## Zadanie 5 - Unit Tests
1. Pobrać kod https://github.com/emilybache/Racing-Car-Katas
2. Dodać testy jednostkowe

## Zadanie 6 A
1. Zidentyfikuj Code smells występujące w zadaniu 3 na podstawie https://refactoring.guru/pl/refactoring/smells
2. Dokonaj refactoringu i popraw istniejące code smells z zadania 3 (jakie techniki zostały użyte https://refactoring.guru/pl/refactoring/techniques)

# Wzorce Projektowe
## Zadanie 7
1. Implementacja struktury drzewiastej firmy (Dyrektor, Członek zarządu, Kierownik wyzszego szczebla, Kierownik niższego szczebla, Scrum Master, Programista)
2. Dodanie do kolekcji :
- 1 dyrektora
- 3 członków zarządu
- 4 kierowników wyższego szczebla
- 6 kierowników niższego szczebla
- 9 scrum masterów
- 14 programistów 

Wylistowanie wszystkich programistów poszczególnych członków zarzadu.

## Zadanie 8 
1. Implementacja różnych strategii obliczania podatku przez użycie wzorca strategii

## Zadanie 9
1. W aplikacji statki zaimplementuj Singleton do logowania zdarzeń
2. Dla każdej akcji z graczy wywołaj logowanie akcji do konsoli (obserwator)
3. Zastąp ruch gracza wzorcem command (umożliwia wycofanie ruchu)
4. Tworzenie graczy z użyciem wzorca builder (fluent builder)
5. Zastąpienie tworzenia statku wzorcem Factory method
6. Rozszerzenie kazdej z operacji dodawania statku wzorcem dekorator
7. Zapis stanu gry (Memento)

