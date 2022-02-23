using Cupcake;
using Cupcake.GameLoop;

class Program
{
	static void Main(string[] args)
	{
		Game game = new TestGame(800, 600, "Cupcake Engine • Test Program");
		game.Run();
	}
}