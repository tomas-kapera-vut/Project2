# Project2

Vytvořil jsem konzolovou aplikaci, která komunikuje s veřejným API (RestCountries.com). Z něj asynchronně získává informace o státech světa a následně provádí jejich analýzu.

Struktura:
-Datové modely (slouží jako šablony pro mapování přijatého Jsonu).
-Třída pro stahování dat.
-Třída pro matematiku a výpočty (CountryAnalyzer).
-Hlavní program, který řídí výpis do konzole.
-Pro stahování jsem vytvořil rozhraní (IDataProvider). Kdybych chtěl v budoucnu načítat data třeba ze souboru, nemusím přepisovat celou logiku.

Práce se sítí a asynchronita:
Odesílání HTTP dotazů probíhá přes HttpClient a je plně asynchronní (využití async a await). Hlavní vlákno se tak neblokuje čekáním na odpověď od serveru. Jakmile data dorazí, rovnou je převádím pomocí System.Text.Json.

Analýza dat přes LINQ:
Místo psaní složitých cyklů zpracovávám stažená data pomocí dotazů LINQ:
Počítám celosvětový průměr počtu obyvatel pomocí metody .Average().
Vyhledávám stát s nejmenší a největší rozlohou. U toho zároveň přes metodu .Where() rovnou filtruji data tak, abych ignoroval území s nulovou rozlohou, která by zkreslila výsledky, a zbytek jednoduše seřadím přes .OrderBy

Ošetření chyb:
Protože komunikace se serverem nemusí vždy vyjít, obalil jsem klíčové části kódu do bloku try-catch. Kdyby API nefungovalo nebo spadlo připojení k internetu, aplikace nespadne, ale bezpečně se ukončí s tím, že do konzole popíše, co se přesně stalo.
