using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue a single item and then dequeue it.
    // Expected Result: The item is dequeued successfully.
    // Defect(s) Found: No defects found. The test passed successfully.
    public void TestPriorityQueue_SingleItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 1);
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Item1", result, "The dequeued item should match the enqueued item.");
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities and dequeue them.
    // Expected Result: Items are dequeued in order of highest priority.
    // Defect(s) Found: No defects found. The test passed successfully.
    public void TestPriorityQueue_MultiplePriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("LowPriority", 1);
        priorityQueue.Enqueue("HighPriority", 5);
        priorityQueue.Enqueue("MediumPriority", 3);

        Assert.AreEqual("HighPriority", priorityQueue.Dequeue(), "The highest priority item should be dequeued first.");
        Assert.AreEqual("MediumPriority", priorityQueue.Dequeue(), "The next highest priority item should be dequeued.");
        Assert.AreEqual("LowPriority", priorityQueue.Dequeue(), "The lowest priority item should be dequeued last.");
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority and dequeue them.
    // Expected Result: Items with the same priority are dequeued in FIFO order.
    // Defect(s) Found: No defects found. The test passed successfully.
    public void TestPriorityQueue_SamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 2);
        priorityQueue.Enqueue("Item2", 2);
        priorityQueue.Enqueue("Item3", 2);

        Assert.AreEqual("Item1", priorityQueue.Dequeue(), "The first item with the same priority should be dequeued first.");
        Assert.AreEqual("Item2", priorityQueue.Dequeue(), "The second item with the same priority should be dequeued next.");
        Assert.AreEqual("Item3", priorityQueue.Dequeue(), "The third item with the same priority should be dequeued last.");
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: An exception is thrown with the message "The queue is empty."
    // Defect(s) Found: No defects found. The test passed successfully.
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue(), "An exception should be thrown when dequeuing from an empty queue.");
    }

    [TestMethod]
    // Scenario: Enqueue items with mixed priorities and ensure the queue maintains correct behavior.
    // Expected Result: Items are dequeued in the correct order based on priority and FIFO for ties.
    // Defect(s) Found: No defects found. The test passed successfully.
    public void TestPriorityQueue_MixedPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 3);
        priorityQueue.Enqueue("Item2", 5);
        priorityQueue.Enqueue("Item3", 3);
        priorityQueue.Enqueue("Item4", 1);

        Assert.AreEqual("Item2", priorityQueue.Dequeue(), "The highest priority item should be dequeued first.");
        Assert.AreEqual("Item1", priorityQueue.Dequeue(), "The first item with the next highest priority should be dequeued.");
        Assert.AreEqual("Item3", priorityQueue.Dequeue(), "The second item with the same priority should be dequeued.");
        Assert.AreEqual("Item4", priorityQueue.Dequeue(), "The lowest priority item should be dequeued last.");
    }
}