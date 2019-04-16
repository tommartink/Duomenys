# Duomenys
Duomenuapdorojimas


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

