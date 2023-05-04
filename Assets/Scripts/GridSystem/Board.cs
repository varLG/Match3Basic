

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

	//Board �rnekleri klonlarken i�imi kolayla�t�rmas� i�in overload yapt�m
	public Board(Board board)
	{
		Width = board.Width;
		Height = board.Height;
		Grid = (int[])board.Grid.Clone();
	}
}