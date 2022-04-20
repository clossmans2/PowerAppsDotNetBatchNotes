using System;

//T is the type that tells the compiler something is generic
public class Day3<T> {
	//inner class. only useable here
	private class Node {
		public Node? Next { get; set; }
		public T Data { get; set; }

		public Node(T t) {
			Next = null;
			Data = t;
        }
	}

	private Node? head;

	public Day3() {
		head = null;
	}

	public void AddHead(T t) {
		Node n = new Node(t);
		n.Next = head;
		head = n;
    }

	public void Print() {
		Node? current = head;

		while (current != null) {
			Console.WriteLine(current.Data);
			current = current.Next;
        }
    }

	public T Get(int i) {
		int count = 0;
		Node? current = head;

		while (count < i) {
			current = current.Next;
			count++;
        }

		return current.Data;
    }
}