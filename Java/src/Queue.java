
public class Queue<T> {
	private LinkedList<T> list = new LinkedList<T>();
	
	private int size = 0;
	
	public int getSize() {
		return size;
	}
	
	/**
	 * Adds the value to the end of the queue. Does nothing if the value is null.
	 * @param value
	 */
	public void enqueue(T value) {
		if(value == null) return;
		list.addToTail(value);
		size++;
	}
	
	/**
	 * Returns and removes the next value from the queue. Returns null if the queue is null or empty.
	 * @return
	 */
	public T dequeue() {
		if(list == null) return null;
		if(list.getHeadValue() == null) return null;
		T nextValue = list.getHeadValue();
		list.removeHead();
		size--;
		return nextValue;
	}

	public String toString() {
		return list.toString();
	}
}
