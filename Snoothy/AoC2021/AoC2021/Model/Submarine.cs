namespace AoC2021.Model
{
    public class Submarine
    {

        public int aim  { get; set; }  // The aim of the submarine.
        public int x { get; set; }  // The X coordinate of the submarine.
        public int y { get; set; }  // The Y coordinate of the submarine.

        // Move the submarine x units in the given direction.
        public void Move(string direction, int units)
        {
            switch (direction)
            {
                case "up":
                    //y += units;
                    aim -= units;
                    break;
                case "down":
                    //y -= units;
                    aim += units;
                    break;
                case "forward":
                    x += units;
                    y += aim*units;
                    break;
                case "backwards":
                    x -= units;
                    break;
            }
        }
        
        // Get x times y.
        public int Multiply()
        {
            return x * y;
        }

        public int GetResult(){
            return Multiply();
        }
        public void AddInstruction(string instruction)
        {
            string[] split = instruction.Split(' ');
            string direction = split[0];
            int units = int.Parse(split[1]);
            Move(direction, units);
        }
        
    }
}