using System.Collections.Generic;

namespace Game
{
    /*
     * Player class that has the player's properties
     */
    public class Player
    {
        public string name;
        public string image;
        public List<int> myBoard;
        public List<int> claimedPositions;
        public int index;

        public Player(int index, string name, string image, List<int> board)
        {
            this.index = index;
            this.name = name;
            this.image = image;
            this.myBoard = board;
            this.claimedPositions = new List<int>();
        }

        /*
         * this method disables the position of the value on the board of this player
         */
        public bool UpdateDataInBoard(int val)
        {
            int myPosition = myBoard.IndexOf(val);
            claimedPositions.Add(myPosition);
            if (index == GameState.MyIndex)
            {
                BoardState.GetInstance().ClickAButton(myPosition);
            }
            return BingoCheck.CheckForBingo(this);
        }

    }
}
