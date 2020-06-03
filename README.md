# Unity ML Agents: Cartpole
A preview of the power of Unity's new ML Agents package.

## Description
This Unity project, utilises Unity's latest ML Agents package, to effectively train a cartpole agent (see the [inverted pendulum problem](https://en.wikipedia.org/wiki/Inverted_pendulum) for more info) that can support that pole for longer than a human may be able to. The models that have been trained in this project were only trained for around 10-20 minutes, under a single instance.

## Why?
Unity's ML Agents package was officially released in May 2020. That's when I decided to test out how easy it is to use, how effective it is, and what it might be useful for. Machine Learning has been something that has interested for a long time, since my brother is well-trained in this topic. This project just happened to be the perfect mix of machine learning and game development; and I couldn't be happier with the result.

## Setup
# Prerequisites
In order to run this project on your computer, you will need Unity 2019.3.x or greater. I haven't included a built version of the game in this repo as I feel that the most important thing in regards to this project is it's inner workings.

However, if you are wanting to train the model yourself, or test out the process, you will need:
```
Python 3.7/3.8
mlagents
```

## Installing
Run the following commands in your command prompt to install the prerequsities listed above:
```
pip install mlagents
```
This should also install the required tensorflow package, but if, for some reason, it fails to do so, run the following command:
```
pip install tensorflow
```

# License
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
