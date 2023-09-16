﻿using Domain.Entity;

namespace Domain.Models;

public class Team : EntityBase
{
    public string Name { get; set; }
    public List<Player> Players { get; set; } = new();
}