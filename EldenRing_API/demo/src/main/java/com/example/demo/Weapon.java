package com.example.demo;

import org.springframework.data.mongodb.core.mapping.MongoId;

import java.util.List;


public class Weapon
{
    @MongoId
    private String _id;
    private String name;
    private String image;
    private String description;
    private List<Attribute> attack;
    private List<Attribute> defence;
    private List<Scaling> scalesWith;
    private List<Attribute> requiredAttributes;
    private String category;
    private Float weight;

    public Weapon(String name, String image, String description, List<Attribute> attack, List<Attribute> defence, List<Scaling> scalesWith, List<Attribute> requiredAttributes, String category, Float weight) {
        this.name = name;
        this.image = image;
        this.description = description;
        this.attack = attack;
        this.defence = defence;
        this.scalesWith = scalesWith;
        this.requiredAttributes = requiredAttributes;
        this.category = category;
        this.weight = weight;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getImage() {
        return image;
    }

    public void setImage(String image) {
        this.image = image;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public List<Attribute> getAttack() {
        return attack;
    }

    public void setAttack(Attribute[] attack) {
        this.attack = List.of(attack);
    }

    public List<Attribute> getDefence() {
        return defence;
    }

    public void setDefence(Attribute[] defence) {
        this.defence = List.of(defence);
    }

    public List<Scaling> getScalesWith() {
        return scalesWith;
    }

    public void setScalesWith(Scaling[] scalesWith) {
        this.scalesWith = List.of(scalesWith);
    }

    public List<Attribute> getRequiredAttributes() {
        return requiredAttributes;
    }

    public void setRequiredAttributes(Attribute[] requiredAttributes) {
        this.requiredAttributes = List.of(requiredAttributes);
    }

    public String getCategory() {
        return category;
    }

    public void setCategory(String category) {
        this.category = category;
    }

    public Float getWeight() {
        return weight;
    }

    public void setWeight(Float weight) {
        this.weight = weight;
    }
}
