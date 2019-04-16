# Duomenys
Duomenuapdorojimas

Naudojimos instrukcija: Rinktis iš duotų pasirinkimų įrašant pasirinkimų raides.

0.1v
program.cs List implementacija
ApdorojimasSuMasyvu.cs Array implementacija(pakeisti pagrindine funkcija i main kai bandoma paleisti)

0.2v
Igyvendintas nuskaitymas is failo.
Igyvendintas naujas lenteles rodymas(galutinis pazymis skaiciuojamas ir rodomas pagal mediana ir vidurki).
Igyvendintas saraso rusiavimas pagal vardus.

0.3v
Studento klasė perkelta į atskirą .cs failą.
Įvedimo iš failo, rašymo ranka ir duomenų pateikimo procedūros sudėtos į atskiras funkcijas.
Sutvarkyti exceptionai su duomenimis paimtais iš failo.
Sutvarkyti exceptionai su duomenimis įrašytais klaviatūra.

0.4v
Sukurta galimybė kurti studentų sąrašus su atsitinktiniais pažymiais.
Sukurta galimybė studentų sarašus patalpinti į failą.
Sukurta galimybė atkirti studentus pagal jų galutinius balus.
Patobulinta failų nuskaitymo funkcija.
Pakeista atsitintinių studentų generavimo funkcija.
Studentų sąrašų kūrimo ir generavimo laikų sekimas(sąrašai buvo skaidomi į du pagal mokymosi lygi):
10 įrašų - 1846ms
100 įrašų - 2923ms
1000 įrašų - 4207ms
10000 įrašų - 11482ms
100000 įrašų - 14928ms

0.5v
Versijoje buvo pridėta galimybė ištestuoti programos veikimo spartą tarp 3 konteinerių: List<>, LinkedList<> ir Queue<>. Testo metu programai duodamas pasirinktas failas, kuris turi n studentų duomenų. Įšmatuojama per kiek laiko programa nuskaitys faila į visus konteinerius ir per kiek laiko ji išskaidys studentus į geresnių ir blogesnių konteinerius. Taip pat pridedama spartos ataskaita atlikta su failais, kurie tūrėjo 10000, 100000, 1000000 įrašų savyje.

Šioje programos versijoje buvo tikrinamos dvi rūšiavimo strategijjos su trėjų tipų konteineriais List<>, LinkedList<>, Queue<>. Testas buvo darytas su 100000 tūkstančių dydžio duomenų rinkiniu. Rezultatai:
Studentai buvo išdalinti per: 3ms naudojant List<Student> pirma strategija
Naudojant List<Student> pirma stategija atminties buvo užimta 22513kb
Studentai buvo išdalinti per: 3ms naudojant LinkedList<Student> pirma strategija
Naudojant LinkedList<Student> pirma stategija atminties buvo užimta 26427kb
Studentai buvo išdalinti per: 5ms naudojant Queue<Student> pirma strategija
Naudojant Queue<Student> pirma stategija atminties buvo užimta 22494kb
----------------------------------------------------------------------------------
Studentai buvo išdalinti per: 4ms naudojant List<Student> antrą strategija
Naudojant List<Student> antrą stategija atminties buvo užimta 21470kb
Studentai buvo išdalinti per: 613674ms naudojant LinkedList<Student> antrą strategija
Naudojant LinkedList<Student> antrą stategija atminties buvo užimta 23813kb
Studentai buvo išdalinti per: 4ms naudojant Queue<Student> antrą strategiją
Naudojant Queue<Student> antrą stategiją atminties buvo užimta 21469kb

Taip pat buvo patikrintas programos veikimas naudojant List.EmementAt komandą.
