package com.example.demo;

import lombok.Data;


public class Scaling
{
    private String name;
    private String scaling;

    public Scaling(String name, String scaling) {
        this.name = name;
        this.scaling = scaling;
    }

    public String getName() {
        return name;
    }

    public String getScaling() {
        return scaling;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setScaling(String scaling) {
        this.scaling = scaling;
    }
}
