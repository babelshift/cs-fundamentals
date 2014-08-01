public class Program {

	public static void main(String[] args) {
		testQueue();
		testStack();
		testLinkedList();
	}

	private static void testQueue() {
		Queue<Integer> queue = new Queue<Integer>();
		queue.enqueue(10);
		queue.enqueue(5);
		queue.enqueue(66);
		queue.enqueue(12);
		System.out.println(queue.dequeue());
		System.out.println(queue.toString());
	}

	private static void testLinkedList() {
		LinkedList<Integer> list = new LinkedList<Integer>();
		list.addToTail(5);
		list.addToTail(10);
		list.addToTail(2);
		list.addToTail(55);
		list.addToTail(17);
		list.addToHead(1);
		System.out.println(list.toString());
	}

	private static void testStack() {
		MinMaxStack<Integer> stack = new MinMaxStack<Integer>();
		stack.push(5);
		stack.push(10);
		stack.push(11);
		stack.push(12);
		stack.push(3);
		stack.push(14);
		System.out.println(stack.toString());
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
