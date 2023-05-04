

[System.Serializable]
public class Board
{
	public int Width { get; private set; }
	public int Height { get; private set; }
	public int[] Grid { get; private set; }

	public Board(int width, int height, int[] grid)
	{
		Width = width;
		Height = height;
		Grid = grid;
	}

	//Board örnekleri klonlarken iþimi kolaylaþtýrmasý için overload yaptým
	public Board(Board board)
	{
		Width = board.Width;
		Height = board.Height;
		Grid = (int[])board.Grid.Clone();
	}
}