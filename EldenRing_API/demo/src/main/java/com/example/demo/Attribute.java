package com.example.demo;

import lombok.Data;

public class Attribute
{
    public String getName() {
        return name;
    }

    public Integer getAmount() {
        return amount;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setAmount(Integer amount) {
        this.amount = amount;
    }

    private String name;
    private Integer amount;

    public Attribute(String name, Integer amount) {
        this.name = name;
        this.amount = amount;
    }
}
