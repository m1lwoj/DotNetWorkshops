# ADO/NET / EF
## Zadanie 1 
1. Utworzyć nowy projekt
2. w konsoli zainstalować:
Install-Package Microsoft.EntityFrameworkCore.Tools 
Install-Package Microsoft.EntityFrameworkCore.SqlServer

3. Uzywając komendy, wygenerować klasy dla bazy danych Scaffold-DbContext "Server=.\SQLExpress;Database=Northwind;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -DataAnnotations

## Zadanie 2.
1. Pobrać istniejący projekt (można zrobić fork)
2. Uzupełnić brakujące metody w CustomersADONETRepository.cs 
3. Napisać zapytanie pobierające wszystkich pracowników z wybranego regionu
4. Dodać metodę pobierającą 5 najlepiej sprzedających pracowników wraz z kwotą ich sprzedaży
5. Dodać metodę dodające nowe zamówienie wraz z dodaniem nowego produktu w nowej kategorii, przez nowego klienta i obecnego pracownika (transakcja)

## Zadanie 3.
1. Adekwatnie do Zadania 2. zrobić to samo używając entity framework (CustomersEfRepository)
