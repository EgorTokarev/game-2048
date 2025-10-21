using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
    
    



    
    
    public class Human : Animal
    {
        private string _strahovka = "0001";

        public new string Answer(string zapros)
        {
            return "Мне понятен ваш запрос: " + zapros;
        }

        public string Strahovka
        {
            get { return _strahovka; }
            set { _strahovka = value; }
        }
        public Human()
        {
            Name = "Человек";
        }
        
    }






    public class Animal
    {
        public static double g = 10; 
        
        private string _name = "Животное";
        private int _height = 0;
        private int _wigth = 0;
        private int _age = 0;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }        

        public virtual string Answer(string zapros)
        {
            return "Ррррррррррррррррр!!!!";
        }

        public string FirstVoice()
        {
            return _name + " орет - Ррррррррррррррррр!!!!";

        }

        public int Height
        {
            get 
            { 
                return _height; 
            }
            set 
            {                
                _height = (value > 0)?(value):0; 
            }
        }

        public int Wigth
        {
            get { return _wigth; }
            set { _wigth = value; }
        }

        /// <summary>
        /// Возраст животного
        /// </summary>
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public Animal()
        {

        }
        public Animal(int age)
        {
            _age = age;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name">Имя животного</param>
        /// <param name="wigth">Вес животного, по умолчанию 100</param>
        public Animal(string name, int wigth=100)
        {
            _wigth = wigth;
            _name = name;
        }
    }
}
