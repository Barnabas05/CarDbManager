# Autó Nyilvántartó Rendszer (CarDbManager)

Ez egy egyszerű WPF alkalmazás C# nyelven, amely autók nyilvántartására szolgál. Az autók adatai egy külső szövegfájlban (`cars.txt`) tárolódnak.

## Fő funkciók

- Autók listázása egy `DataGrid`-ben
- Autó hozzáadása egyszerű űrlapon keresztül (gyártó, modell, évjárat, ár)
- Autó adatainak szerkesztése
- Autó törlése
- Autók szűrése évjárat alapján (tól-ig)
- Autók szűrése gyártó és modell alapján
- Minta autók hozzáadása gombnyomásra

## Adatkezelés

Az autók adatai egy `cars.txt` nevű szövegfájlban vannak tárolva, egyszerű sorosított formában (egy autó egy sor, mezők pontosvesszővel elválasztva).

## Autó hozzáadásakor végzett ellenőrzések

Az `AddCarWindow`-ban az alábbi alapvető validációk történnek:

- Gyártó és modell mezők nem lehetnek üresek
- Az évjárat egy 1900 és a jelenlegi év közötti egész szám kell legyen
- Az ár nem lehet negatív és csak szám lehet

Ha valamelyik adat nem megfelelő, a program egy felugró hibaüzenetet (`MessageBox`) jelenít meg, és az adott mező kapja a fókuszt a könnyebb javítás érdekében.

## Fájl struktúra

- `MainWindow.xaml` – fő ablak az autók listázásához és szűréséhez
- `AddCarWindow.xaml` – ablak új autó hozzáadásához
- `EditCarWindow.xaml` – ablak meglévő autó adatainak szerkesztéséhez
- `CarDb.cs` – az autók beolvasásáért és mentéséért felelős statikus osztály


---


