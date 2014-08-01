
public class Stack<T extends Comparable<T>> {
	private LinkedList<T> list = new LinkedList<T>();
	
	private int size = 0;
	
	public int getSize() {
		return size;
	}

	/**
	 * Returns the top of the stack. Returns null if the stack is empty.
	 */
	public T peek() {
		if(list == null) return null;
		if(list.getHeadValue() == null) return null;
		return list.getHeadValue();
	}

	/**
	 * Pushes the value to the top of the stack. Does nothing if the value is null.
	 */
	public void push(T value) {
		if(value == null) return;
		list.addToHead(value);
		size++;
	}

	/**
	 * Returns the top of the stack and removes it from the stack. Returns null if the stack is empty.
	 */
	public T pop() {
		if(list == null) return null;
		if(list.getHeadValue() == null) return null;
		T topValue = list.getHeadValue();
		list.removeHead();
		size--;
		return topValue;
	}
}
