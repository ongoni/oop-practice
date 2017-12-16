﻿using System;
using System.Data;
using System.IO;
using OOPPractice.CountingRhyme;
using OOPPractice.Patterns.AbstractFactory;
using OOPPractice.Patterns.AbstractFactory.Factories;
using OOPPractice.Patterns.Adapter;
using OOPPractice.Patterns.Adapter.AdaptedTransport;
using OOPPractice.Patterns.Adapter.Animal;
using OOPPractice.Patterns.Adapter.Transport;
using OOPPractice.Patterns.Builder;
using OOPPractice.Patterns.Builder.Builder;
using OOPPractice.Patterns.Builder.MagicStaff;
using OOPPractice.Patterns.Decorator.Decorators;
using OOPPractice.Patterns.Decorator.Weapons;
using OOPPractice.Patterns.Facade.Specialists.Government;

namespace OOPPractice.Patterns {

    public class Tasks {

        public static void countingRhyme() {
            Console.Write("Enter k: ");
            int k = int.Parse(Console.ReadLine());

            LoopedDoubleLinkedList list = new LoopedDoubleLinkedList();
            using (StreamReader sr = new StreamReader("../../input.txt")) {
                foreach (string item in sr.ReadToEnd().Split(' ')) {
                    list.Add(item);
                }
            }

            list.Show();
            int counter = 1;
            foreach (var item in list) {
                if (counter == k) {
                    list.Remove((string)item);
                    counter = 0;
                }
                counter++;
                
                if (list.Count == 1) break;
            }
            
            Console.WriteLine();
            list.Show();
        }
        
        public static void abstractFactory() {
            Hero mage = new Hero(new MageFactory());
            Hero rogue = new Hero(new RogueFactory());
            
            mage.Move();
            mage.Hit();
            
            rogue.Move();
            rogue.Hit();
        }

        public static void adapter() {
            Traveler traveler = new Traveler();
            HorseAndCart horseAndCart = new HorseAndCart();
            traveler.Travel(horseAndCart);
            
            Horse horse = new Horse();
            Transport horseTransport = new HorseTransportAdapter(horse);
            traveler.Travel(horseTransport);
        }

        public static void builder() {
            Mage mage = new Mage();
            
            MagicStaff fireMagicStaff = mage.CreateMagicStaff(new FireMagicStaffBuilder());
            MagicStaff drakonidMagicStaff = mage.CreateMagicStaff(new DrakonidMagicStaffBuilder());
            
            Console.WriteLine(fireMagicStaff);
            Console.WriteLine(drakonidMagicStaff);
        }

        public static void decorator() {
            MeleeWeapon sword = new Sword();
            Console.WriteLine(sword);
            sword = new EnchantedMeleeWeapon(sword);
            Console.WriteLine(sword);
            sword = new SharpenedMeleeWeapon(sword);
            Console.WriteLine(sword);
            
            MeleeWeapon dagger = new Dagger();
            Console.WriteLine(dagger);
            dagger = new EnchantedMeleeWeapon(dagger);
            Console.WriteLine(dagger);
            dagger = new OiledMeleeWeapon(dagger);
            Console.WriteLine(dagger);
            dagger = new SharpenedMeleeWeapon(dagger);
            Console.WriteLine(dagger);
        }

        public static void facade() {
            King king = new King();
            king.OrderToStartCrusade();
            king.OrderToStopCrusade();
        }

        public static void flyWeight() {
            
        }

        public static void singleton() {
            
        }

        public static void strategy() {
            
        }
        
    }

}