public class Program {

	public static void main(String[] args) {
		MinMaxStack<Integer> stack = new MinMaxStack<Integer>();
		stack.push(5);
		stack.push(10);
		stack.push(11);
		stack.push(12);
		stack.push(3);
		stack.push(14);
		System.out.println("Min/max before: " + stack.getMinimum() + "," + stack.getMaximum() + ", Value: " + stack.pop() + ", Min/max after: " + stack.getMinimum() + "," + stack.getMaximum());
		System.out.println("Min/max before: " + stack.getMinimum() + "," + stack.getMaximum() + ", Value: " + stack.pop() + ", Min/max after: " + stack.getMinimum() + "," + stack.getMaximum());
		System.out.println("Min/max before: " + stack.getMinimum() + "," + stack.getMaximum() + ", Value: " + stack.pop() + ", Min/max after: " + stack.getMinimum() + "," + stack.getMaximum());
		System.out.println("Min/max before: " + stack.getMinimum() + "," + stack.getMaximum() + ", Value: " + stack.pop() + ", Min/max after: " + stack.getMinimum() + "," + stack.getMaximum());
		System.out.println("Min/max before: " + stack.getMinimum() + "," + stack.getMaximum() + ", Value: " + stack.pop() + ", Min/max after: " + stack.getMinimum() + "," + stack.getMaximum());
		System.out.println("Min/max before: " + stack.getMinimum() + "," + stack.getMaximum() + ", Value: " + stack.pop() + ", Min/max after: " + stack.getMinimum() + "," + stack.getMaximum());
		System.out.println("Min/max before: " + stack.getMinimum() + "," + stack.getMaximum() + ", Value: " + stack.pop() + ", Min/max after: " + stack.getMinimum() + "," + stack.getMaximum());
		System.out.println("Min/max before: " + stack.getMinimum() + "," + stack.getMaximum() + ", Value: " + stack.pop() + ", Min/max after: " + stack.getMinimum() + "," + stack.getMaximum());
	}
}
