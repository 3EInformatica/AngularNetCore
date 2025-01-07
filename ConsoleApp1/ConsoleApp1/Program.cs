List<int> numeri = new List<int>();   
numeri.Add(25);
numeri.Add(19);
numeri.Add(39);

foreach (int numero in numeri)
{
    Console.WriteLine(numero);
}

//int valoreMinimo = numeri.Min();
//int valoreMassimo = numeri.Max();
int valoreMassimo= 0;
foreach (int numero in numeri)
{
    if (numero > valoreMassimo)
    {
        valoreMassimo = numero;
    }
}
int valoreMinimo = valoreMassimo;
foreach (int numero in numeri)
{
    if (numero < valoreMinimo)
    {
        valoreMinimo = numero;
    }
}

Console.WriteLine("Valore minimo: " + valoreMinimo);
Console.WriteLine("Valore massimo: " + valoreMassimo);

///ORDINAMENTO
///
//List<int> numeriOrdinati = numeri.OrderBy(x => x).ToList();
List<int> numeriOrdinati = new List<int>();
while (numeri.Count > 0)
{
    int valoreMin = numeri[0];
    foreach (int numero in numeri)
    {
        if (numero < valoreMin)
        {
            valoreMin = numero;
        }
    }
    numeriOrdinati.Add(valoreMin);
    numeri.Remove(valoreMin);
}

foreach (int numero in numeriOrdinati)
{
    Console.WriteLine(numero);
}

