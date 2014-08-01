
public class LinkedList<T> {
	private LinkedListNode<T> head;
	private LinkedListNode<T> tail;
	
	/**
	 * Returns the head value of the list. Returns null if the head is null.
	 * @return
	 */
	public T getHeadValue() {
		if(head == null) return null;
		return head.getData();
	}
	
	public void removeHead() {
		LinkedListNode<T> top = head;
		head = head.getNext();
		top.setNext(null);
	}
	
	/**
	 * Adds the passed value to the tail of the list. Does nothing if the value is null.
	 * @param value
	 */
	public void addToTail(T value) {
		if(value == null) return;
		
		LinkedListNode<T> node = new LinkedListNode<T>(value);
		if(head == null) {
			head = node;
			tail = node;
		} else {
			tail.setNext(node);
			tail = node;
		}
	}
	
	/**
	 * Adds the passed value to the head of the list. Does nothing if the value is null.
	 * @param value
	 */
	public void addToHead(T value) {
		if(value == null) return;

		LinkedListNode<T> node = new LinkedListNode<T>(value);
		if(head == null) {
			head = node;
			tail = node;
		} else {
			node.setNext(head);
			head = node;
		}
	}
	
	/**
	 * Returns a comma delimited string containing all values in the list.
	 */
	public String toString() {
		if(head == null) return null;
		
		StringBuilder sb = new StringBuilder();
		LinkedListNode<T> node = head;
		while(node != null) {
			sb.append(node.getData() + ", ");
			node = node.getNext();
		}
		
		String result = sb.toString();
		result = result.substring(0, result.length() - 2);

		return result;
	}
}
