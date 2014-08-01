
public class Stack<T extends Comparable<T>> {
	private LinkedListNode<T> head;
	
	private int size = 0;
	
	public int getSize() {
		return size;
	}
	
	public T peek() {
		if(head == null) return null;
		return head.getData();
	}
	
	public void push(T value) {
		if(value == null) return;
		LinkedListNode<T> top = new LinkedListNode<T>(value);
		top.setNext(head);
		head = top;
		size++;
	}
	
	public T pop() {
		if(head == null) return null;
		LinkedListNode<T> top = head;
		head = head.getNext();
		top.setNext(null);
		size--;
		return top.getData();
	}
}
