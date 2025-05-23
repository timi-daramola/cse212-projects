using System;
using System.Collections.Generic;

public class TakingTurnsQueue
{
    private readonly Queue<Person> _people = new();

    public int Length => _people.Count;

    /// <summary>
    /// Add a new person to the queue with a name and number of turns.
    /// </summary>
    /// <param name="name">Name of the person</param>
    /// <param name="turns">Number of turns remaining</param>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Get the next person in the queue and return them. The person should
    /// go to the back of the queue again unless the turns variable shows that they 
    /// have no more turns left. Note that a turns value of 0 or less means the 
    /// person has an infinite number of turns. An error exception is thrown 
    /// if the queue is empty.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.Count == 0)
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        var person = _people.Dequeue();

        // Handle infinite turns (Turns <= 0)
        if (person.Turns <= 0)
        {
            _people.Enqueue(person);
        }
        // Handle finite turns (Turns > 1)
        else if (person.Turns > 1)
        {
            person.Turns -= 1;
            _people.Enqueue(person);
        }
        // If Turns == 1, do not re-enqueue the person (they are out of turns)

        return person;
    }

    public override string ToString()
    {
        return string.Join(", ", _people);
    }
}
