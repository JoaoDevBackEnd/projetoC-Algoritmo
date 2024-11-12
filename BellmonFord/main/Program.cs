using System;
using System.Collections.Generic;

public class Aresta
{
    public int Origem { get; set; }
    public int Destino { get; set; }
    public int Peso { get; set; }

    public Aresta(int origem, int destino, int peso)
    {
        Origem = origem;
        Destino = destino;
        Peso = peso;
    }
}

public class Grafo
{
    public int V { get; set; } // Número de vértices
    public List<Aresta> Arestas { get; set; }

    public Grafo(int v)
    {
        V = v;
        Arestas = new List<Aresta>();
    }

    public void AdicionarAresta(int origem, int destino, int peso)
    {
        Arestas.Add(new Aresta(origem, destino, peso));
    }

    public bool BellmanFord(int origem, int[] distancias, int[] predecessores)
    {
        // Inicializa as distâncias e predecessores
        Array.Fill(distancias, int.MaxValue);
        distancias[origem] = 0;

        // Relaxar as arestas V - 1 vezes
        for (int i = 1; i <= V - 1; i++)
        {
            foreach (var aresta in Arestas)
            {
                int u = aresta.Origem;
                int v = aresta.Destino;
                int peso = aresta.Peso;

                if (distancias[u] != int.MaxValue && distancias[u] + peso < distancias[v])
                {
                    distancias[v] = distancias[u] + peso;
                    predecessores[v] = u;
                }
            }
        }

        // Verifica ciclos negativos
        foreach (var aresta in Arestas)
        {
            int u = aresta.Origem;
            int v = aresta.Destino;
            int peso = aresta.Peso;

            if (distancias[u] != int.MaxValue && distancias[u] + peso < distancias[v])
            {
                return true; // Ciclo negativo encontrado
            }
        }

        return false;
    }

    // Recupera o caminho mais curto de origem até destino
    public List<int> RecuperarCaminho(int[] predecessores, int destino)
    {
        List<int> caminho = new List<int>();
        for (int v = destino; v != -1; v = predecessores[v])
        {
            caminho.Insert(0, v);
        }
        return caminho;
    }
}

public class Program
{
    public static void Main()
    {
        // Criação do grafo
        Grafo grafo = new Grafo(50); // 50 vértices (de 1 a 50)

        // Adicionando as arestas (usando os dados que você forneceu)
        grafo.AdicionarAresta(1, 2, 10);
        grafo.AdicionarAresta(2, 45, 15);
        grafo.AdicionarAresta(2, 50, 8);
        grafo.AdicionarAresta(3, 44, 12);
        grafo.AdicionarAresta(3, 21, 18);
        grafo.AdicionarAresta(3, 4, 20);
        grafo.AdicionarAresta(4, 49, 110);
        grafo.AdicionarAresta(4, 41, 24);
        grafo.AdicionarAresta(4, 22, 89);
        grafo.AdicionarAresta(4, 17, 21);
        {from: 5, to: 4, label: '41 Min',arrows:'none'},
            {from: 5, to: 8, label: '13 Min',arrows:'none'},
            {from: 5, to: 31, label: '5 Min',arrows:'none'},
            {from: 5, to: 32, label: '89 Min',arrows:'none'},
            {from: 5, to: 15, label: '12 Min',arrows:'none'},

            {from: 6, to: 23, label: '27 Min',arrows:'none'},
            {from: 6, to: 22, label: '36 Min',arrows:'none'},
            {from: 6, to: 26, label: '33 Min',arrows:'none'},
            {from: 6, to: 47, label: '45 Min',arrows:'none'},
            {from: 6, to: 45, label: '37 Min',arrows:'none'},

            {from: 7, to: 10, label: '12 Min',arrows:'none'},
            {from: 7, to: 35, label: '9 Min',arrows:'none'},
            {from: 7, to: 33, label: '87 Min',arrows:'none'},
            {from: 7, to: 14, label: '142 Min',arrows:'none'},
            {from: 7, to: 21, label: '11 Min',arrows:'none'},

            {from: 8, to: 49, label: '41 Min',arrows:'none'},
            {from: 8, to: 42, label: '35 Min',arrows:'none'},
            {from: 8, to: 37, label: '26 Min',arrows:'none'},
            {from: 8, to: 24, label: '41 Min',arrows:'none'},
            {from: 8, to: 18, label: '52 Min',arrows:'none'},
            {from: 8, to: 34, label: '57 Min',arrows:'none'},
            {from: 2, to: 6, label: '25 Min', arrows: 'none'},
            {from: 3, to: 8, label: '30 Min', arrows: 'none'},
            {from: 4, to: 10, label: '15 Min', arrows: 'none'},
            {from: 5, to: 12, label: '17 Min', arrows: 'none'},
            {from: 6, to: 14, label: '45 Min', arrows: 'none'},
            {from: 7, to: 19, label: '22 Min', arrows: 'none'},
            {from: 8, to: 25, label: '33 Min', arrows: 'none'},
            {from: 9, to: 46, label: '28 Min', arrows: 'none'},
            {from: 10, to: 36, label: '12 Min', arrows: 'none'},
            {from: 11, to: 27, label: '14 Min', arrows: 'none'},
            {from: 12, to: 28, label: '50 Min', arrows: 'none'},
            {from: 13, to: 29, label: '45 Min', arrows: 'none'},
            {from: 14, to: 30, label: '60 Min', arrows: 'none'},
            {from: 15, to: 31, label: '10 Min', arrows: 'none'},
            {from: 16, to: 32, label: '30 Min', arrows: 'none'},
            {from: 17, to: 33, label: '27 Min', arrows: 'none'},
            {from: 18, to: 34, label: '50 Min', arrows: 'none'},
            {from: 19, to: 35, label: '20 Min', arrows: 'none'},
            {from: 20, to: 36, label: '15 Min', arrows: 'none'},
            {from: 21, to: 37, label: '18 Min', arrows: 'none'},
            {from: 22, to: 38, label: '24 Min', arrows: 'none'},
            {from: 23, to: 39, label: '32 Min', arrows: 'none'},
            {from: 24, to: 40, label: '10 Min', arrows: 'none'},
            {from: 25, to: 41, label: '50 Min', arrows: 'none'},
            {from: 26, to: 42, label: '33 Min', arrows: 'none'},
            {from: 27, to: 43, label: '12 Min', arrows: 'none'},
            {from: 28, to: 44, label: '20 Min', arrows: 'none'},
            {from: 29, to: 45, label: '10 Min', arrows: 'none'},
            {from: 30, to: 46, label: '50 Min', arrows: 'none'},
            {from: 31, to: 47, label: '11 Min', arrows: 'none'},
            {from: 32, to: 48, label: '22 Min', arrows: 'none'},
            {from: 33, to: 49, label: '33 Min', arrows: 'none'},
            {from: 34, to: 50, label: '12 Min', arrows: 'none'},
            {from: 35, to: 43, label: '3 Min', arrows: 'none'},
            {from: 45, to: 19, label: '65 Min', arrows: 'none'},
            {from: 19, to: 30, label: '19 Min', arrows: 'none'},
        // ... adicione todas as arestas conforme o seu exemplo ...

        // Exemplo: verificar ciclo negativo e calcular caminho mais curto
        int origem = 1;  // Ponto de origem
        int destino = 10; // Ponto de destino

        int[] distancias = new int[grafo.V + 1];  // Para armazenar as distâncias
        int[] predecessores = new int[grafo.V + 1]; // Para armazenar os predecessores
        Array.Fill(predecessores, -1);  // Inicializa os predecessores com -1 (nenhum predecessor)

        // Verificando ciclos negativos
        if (grafo.BellmanFord(origem, distancias, predecessores))
        {
            Console.WriteLine("Ciclo negativo detectado!");
        }
        else
        {
            // Calculando o caminho mais curto
            List<int> caminho = grafo.RecuperarCaminho(predecessores, destino);

            // Exibindo o caminho
            Console.WriteLine("Caminho mais curto:");
            foreach (var nodo in caminho)
            {
                Console.Write(nodo + " ");
            }
            Console.WriteLine("\nDistância: " + distancias[destino]);
        }
    }
}
