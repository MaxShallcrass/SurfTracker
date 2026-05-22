# [Project Name]

## Overview

The Surf Session Tracker is a mobile-first application designed for surfers who want to log, track, and review their time in the water with an easy to use and nagivate application. After each session, users can record personal performance stats and surf observations alongside automatically fetched ocean conditions such as swell, wind, and tide data for their surf spot. Over time this builds a personal history of sessions tied to real environmental data, letting surfers identify patterns in their performance and understand which conditions suit their surfing best. It solves the problem of surfers relying on memory to evaluate their progress, replacing vague recollections with a structured, data-backed record of every session.

## Goals

1. Let users sign up or log into the application through a secure authenticated process
2. Record a surf session noting down user inputted data of surf performance stats and observations
3. Data for the surf session recorded from the usage of external API's for wind, swell and tide data
3. Search previous surf sessions using a simple or advanced filter
4. Show a view of previous surf sessions in a user-friendly way
5. Show a consolidated view of previous surf sessions data 


## Core User Flow

1. User signs in
2. User creates or views a surf session
User creates a surf session:
 - 1. Inputs user data for a surf session
 - 2. User can view external api data for swell, wind and tide once user has inputted surf location and time of session
 - 3. Save the data
User views surf session:
 - 1. Surf sessions search either for singular or consolidated view
 - 2. Search functionality basic and advanced
 - 3. View past singular or consolidated surf sessions


## Features

### Sign-up and authentication

- User sign-up
- User sign-in and route protection

### Create a surf session

- Able to save user inputted data about the surf session
- Able to save data from external API's for wind, tide, and swell data


### View a surf session

- Able to search for a search session
- Basic search/filter functionality for ease of use
- Advanced search/filter functionality
- Able to view total surf session details

### Consolidated surf session view

- Able to search for a search session
- Basic search/filter functionality for ease of use
- Advanced search/filter functionality
- Able to view a consolidated view of a surf sessions using a subset of the data available

## Scope

### In Scope

- Authentication and route protection
- Surf session creation and viewability
- Search of previous surf sessions
- Data stored through cloud RDS system
- Building an easy to use application that a user can interact with

### Out of Scope

- Storing data on device

## Success Criteria

1. A signed-in user can create a surf session
2. A signed-in user can search/filter and view past surf sessions singulary
3. A signed-in user can search/filter and view past surf sessions in a consolidated view
4. Userfriendly design for the frontend
5. Structure of the application is loosely coupled in a MVC design pattern with the frontend and backend easily swappable
