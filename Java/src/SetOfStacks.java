import java.util.ArrayList;
import java.util.Stack;


public class SetOfStacks<T> extends Stack<T> {
	private ArrayList<Stack<T>> set = new ArrayList<Stack<T>>();
	private Stack<T> activeStack = new Stack<T>();
	private int threshold = 5;
	
	public SetOfStacks() {
		Stack<T> newStack = new Stack<T>();
		activeStack = newStack;
		set.add(newStack);
	}
	
	public T push(T value) {
		if(activeStack.size() >= threshold) {
			Stack<T> newStack = new Stack<T>();
			activeStack = newStack;
			set.add(newStack);
		}
		activeStack.push(value);
		return value;
	}
	
	public T pop() {
		T value = null;
		
		// if there are no values left in the active stack, try to get the next stack in the set
		if(activeStack.size() == 0) {
			// remove the now empty active stack
			set.remove(activeStack);
			
			// if the next queued active stack is not empty, get a handle on it and pop its top
			if(set.get(set.size() - 1) != null) {
				activeStack = set.get(set.size() - 1);
				value = activeStack.pop();
			}
		// we have a value in the active stack, get it
		} else {
			value = activeStack.pop();
		}
		
		return value;
	}
	
	public T popAt(int index) {
		T value = null;
		
		// if there is a set at the index
		if(set.get(index) != null) {
			// if there are any items in the set at the index, pop it
			if(set.get(index).size() > 0) {
				value = set.get(index).pop();
			}
		}
		
		return value;
	}
}
