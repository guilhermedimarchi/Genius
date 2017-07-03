using System;

namespace Paint
{

    public class Fila
    {
        private object[] elements;
        private int front, rear, tamanho, count;

        /// <summary>
        /// Construtor da fila
        /// </summary>
        /// <param name="tamanho"> Quantidade de Objetos.</param>
        public Fila(int tamanho)
        {
            this.tamanho = tamanho;
            elements = new object[this.tamanho];

            rear = front = 0;
            count = 0;

        }
        /// <summary>
        ///     Retorna se a fila está vazia.
        /// </summary>
        /// <returns>Se vazio retorna verdadeiro, senao retorna falso</returns>
        public bool Empty()
        {
            if (count == 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Retorna se a Fila está cheia
        /// </summary>
        /// <returns>Verdadeiro para cheio</returns>
        public bool Full()
        {

            if (tamanho == count)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Insere um objeto na fila
        /// </summary>
        /// <param name="x">Objeto X.</param>
        public void Insert(object x)
        {
            if (Full())
            {
                throw new Exception("Fila Cheia");
            }
            if (rear == tamanho - 1)
                rear = 0;
            else
                rear++;
            elements[rear] = x;
            count++;


        }

        public object Remove()
        {
            if (Empty())
                throw new Exception("Fila Vazia!!!");

            if (front == tamanho - 1)
                front = 0;
            else
                front++;
            count--;
            return (elements[front]);
        }
        public int contador()
        {
            return count;
        }
    }
}