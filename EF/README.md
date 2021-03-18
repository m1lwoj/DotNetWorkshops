# ADO/NET / EF
## Zadanie 1 
1. Utworzyć nowy projekt
2. w konsoli zainstalować:
Install-Package Microsoft.EntityFrameworkCore.Tools 
Install-Package Microsoft.EntityFrameworkCore.SqlServer

3. Uzywając komendy, wygenerować klasy dla bazy danych Scaffold-DbContext "Server=.\SQLExpress;Database=Northwind;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -DataAnnotations

## Zadanie 2.
1. Pobrać istniejący projekt (można zrobić fork)
2. Uzupełnić metody w CustomersADONETRepository.cs GetAllCustomers, UpdateCustomer
3. Dodać metodę pobierające wszystkich pracowników z wybranego regionu
4. Dodać metodę pobierającą 5 najlepiej sprzedających pracowników wraz z kwotą ich sprzedaży
5. Dodać metodę dodające nowe zamówienie wraz z dodaniem nowego produktu w nowej kategorii, przez nowego klienta i obecnego pracownika (transakcja) https://docs.microsoft.com/pl-pl/dotnet/framework/data/adonet/local-transactions


## Zadanie 3.
1. Adekwatnie do Zadania 2. zrobić to samo używając entity framework (CustomersEfRepository)

## Zadanie 4. 
1. Dopisać testy do OrdersRepository (integracyjne i z bazą in memory, sprawdzające constrainty) ze scenariuszami odzczytu danych ale i dodawania nowych danych, pamiętając o wyczyszczeniu zmian po zakończeniu testów.
2. Tak jak w 1. ale dla CustomersRepository
