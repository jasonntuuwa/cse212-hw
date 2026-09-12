using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue "Low" (priority 1), "High" (priority 5), "Medium" (priority 3).
    // Dequeue all three items.
    // Expected Result: High, Medium, Low (highest priority dequeued first each time)
    // Defect(s) Found: First run gave me "Assert.AreEqual failed. Expected:<Medium>. Actual:<High>."
    // - dequeuing "High" twice in a row meant it was never actually being removed from the list.
    // Traced it to Dequeue() finding the value but never calling RemoveAt on it. Also noticed the
    // for loop was written as index < _queue.Count - 1, which skips checking the very last item
    // in the queue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue "First" (priority 2), "Second" (priority 5), "Third" (priority 5), "Fourth" (priority 1).
    // Dequeue all four items.
    // Expected Result: Second, Third, First, Fourth
    // (Second and Third tie at the highest priority, so Second - being closer to the front - comes out first)
    // Defect(s) Found: Got "Assert.AreEqual failed. Expected:<Second>. Actual:<Third>." - the tiebreaker
    // was picking the wrong one. Found the >= in the priority comparison; since Third has the same
    // priority as Second, >= let it overwrite Second as the "winner." Switching to > fixed it since it
    // only replaces the current pick on a strictly higher priority, letting the earlier tie stay put.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 2);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 5);
        priorityQueue.Enqueue("Fourth", 1);

        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Fourth", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue.
    // Expected Result: An InvalidOperationException should be thrown with the message "The queue is empty."
    // Defect(s) Found: None - this one passed right away, the empty check and exception message were
    // already correct.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    // Add more test cases as needed below.
}