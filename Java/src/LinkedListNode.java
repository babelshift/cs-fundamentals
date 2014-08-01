
public class LinkedListNode<T> {
	private LinkedListNode<T> next;
	private T data;
	
	public LinkedListNode(T data) {
		this.data = data;
	}
	
	public void setNext(LinkedListNode<T> next) {
		this.next = next;
	}
	
	public LinkedListNode<T> getNext() {
		return next;
	}
	
	public void setData(T data) {
		this.data = data;
	}
	
	public T getData() {
		return data;
	}
}
