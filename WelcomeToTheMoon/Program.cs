

namespace WelcomeToTheMoon
{ 
    class Program
    {
        static void Main() //Entry point  
        {
            Console.Title = "Welcome To The Moon - Astra Helper";

            PlayIntroSound();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Bienvenido a Welcome To The Moon - Astra Helper");
            
            var game = new SoloGame();
            game.Start();
        }

        static void PlayIntroSound()
        {
            var tempo = 140;
            var negra = 60000 / tempo;
            var corchea = negra / 2;

            Console.Beep(440, negra / 4*3);
            Console.Beep(880, negra / 4 * 3);
            Console.Beep(660, negra / 4 * 3);
            Console.Beep(440, corchea / 2);
            Console.Beep(660, corchea / 2);
            Console.Beep(880, corchea / 2);

            //Thread.Sleep(negra*2);

            //Console.Beep(659, corchea);
            //Console.Beep(659, corchea);
            //Thread.Sleep(corchea);
            //Console.Beep(659, corchea); 
            //Thread.Sleep(corchea); 
            //Console.Beep(523, corchea); 
            //Console.Beep(659, negra); 

            //Console.Beep(784, negra);
            //Thread.Sleep(negra); 
            //Console.Beep(392, negra);
            //Thread.Sleep(negra);
        }
    }
}