
public class MinMaxStack<T extends Comparable<T>> extends Stack<T> {
	private Stack<T> minStack = new Stack<T>();
	private Stack<T> maxStack = new Stack<T>();

	/**
	 * Returns the minimum value contained within the stack. Returns null if the stack is empty.
	 * @return
	 */
	public T getMinimum() {
		return minStack.peek();
	}
	
	/**
	 * Returns the maximum value contained within the stack. Returns null if the stack is empty.
	 * @return
	 */
	public T getMaximum() {
		return maxStack.peek();
	}
	
	/**
	 * Pushes the value to the top of the stack. Does nothing if the value is null.
	 */
	public void push(T value) {
		super.push(value);
		
		// check if we have a new minimum and add it to the min stack if necessary
		if(minStack.getSize() == 0) {
			minStack.push(value);
		} else {
			int compare = value.compareTo(getMinimum());
			if(compare <= 0) {
				minStack.push(value);
			}
		}
		
		// check if we have a new maximum and add it to the max stack if necessary
		if(maxStack.getSize() == 0) {
			maxStack.push(value);
		} else {
			int compare = value.compareTo(getMaximum());
			if(compare >= 0) {
				maxStack.push(value);
			}
		}
	}
	
	/**
	 * Returns the top of the stack and removes it from the stack. Returns null if the stack is empty.
	 */
	public T pop() {
		T value = super.pop();
		if(value == null) return null;
		// if we just popped the minimum, remove it from our min stack
		if(value.equals(getMinimum())) {
			minStack.pop();
		}
		// if we just popped the maximum, remove it from our max stack
		if(value.equals(getMaximum())) {
			maxStack.pop();
		}
		return value;
	}
}
