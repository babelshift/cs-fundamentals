
public class MinMaxStack<T extends Comparable<T>> extends Stack<T> {
	private Stack<T> minStack = new Stack<T>();
	private Stack<T> maxStack = new Stack<T>();

	public T getMinimum() {
		return minStack.peek();
	}
	
	public T getMaximum() {
		return maxStack.peek();
	}
	
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
		
		if(maxStack.getSize() == 0) {
			maxStack.push(value);
		} else {
			int compare = value.compareTo(getMaximum());
			if(compare >= 0) {
				maxStack.push(value);
			}
		}
	}
	
	public T pop() {
		T value = super.pop();
		if(value == null) return null;
		// if we just popped the minimum, remove it from our min stack
		if(value.equals(getMinimum())) {
			minStack.pop();
		}
		if(value.equals(getMaximum())) {
			maxStack.pop();
		}
		return value;
	}
}
