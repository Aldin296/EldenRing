package com.example.demo;

import org.springframework.data.mongodb.repository.MongoRepository;

public interface WeaponRepository extends MongoRepository<Weapon, String>
{
    void deleteWeaponByName(String name);
    Weapon findWeaponByName(String name);


}
