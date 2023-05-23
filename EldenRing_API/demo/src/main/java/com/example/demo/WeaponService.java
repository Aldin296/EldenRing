package com.example.demo;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Optional;

@Service
public class WeaponService
{
    @Autowired
    private WeaponRepository weaponRepository;

    private List<Weapon> weapons = new ArrayList<>(Arrays.asList());


    public List<Weapon> getallWeapons() {
        return (List<Weapon>) this.weaponRepository.findAll();
    }

    public Optional<Weapon> getWeapon(String name) {
        return Optional.ofNullable(this.weaponRepository.findWeaponByName(name));
    }

    public void addWeapon(Weapon weapon)
    {
        weapons.add(weapon);
        this.weaponRepository.save(weapon);
    }

    public void deleteWeapon(String name)
    {
        this.weaponRepository.deleteWeaponByName(name);
    }

    public void updateWeapon(String name, Weapon weapon)
    {
        this.weaponRepository.save(weapon);
        this.weaponRepository.deleteWeaponByName(name);
    }

}
