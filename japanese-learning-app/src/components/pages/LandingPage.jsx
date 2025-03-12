import React from "react";
import NavBar from "../NavBar";
import TowerImg from "../TowerImg";
import CherryImg from "../CherryImg";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faGraduationCap, faLanguage, faComments, faBookOpenReader } from "@fortawesome/free-solid-svg-icons";

const LandingPage = () => {
  return (
    <div className="min-h-screen text-white">
      <NavBar />

      {/* Hero Section */}
      <div className="hero min-h-screen bg-primary flex items-center justify-center px-6 lg:px-16">
        <div className="hero-content flex flex-col lg:flex-row items-center lg:items-start w-full max-w-6xl">

          {/* Text Content */}
          <div className="lg:w-5/6 text-center lg:text-left">
            <h1 className="text-5xl font-bold">Learn Japanese Effortlessly</h1>
            <p className="py-6 text-lg text-text">
              Dive into the world of Japanese language and culture with interactive lessons and engaging content.
            </p>
            <button className="btn btn-wide btn-secondary text-lg">Get Started</button>
          </div>

          {/* Image Section */}
          <div className="relative lg:w-1/2 flex justify-center lg:justify-end mt-8 lg:mt-0 lg:ml-16">
            <div className="relative w-[350px] lg:w-[400px]">
              {/* Foreground Image (Cherry Blossom) */}
              <div className="absolute bottom-[50px] left-[-300px] transform scale-95 z-10 shadow-lg rounded-lg">
                <CherryImg />
              </div>
              {/* Background Image (Tower) */}
              <div className="relative z-0 lg:ml-16" style={{ top: '-54.5px' }}>
                <TowerImg />
              </div>
            </div>
          </div>

        </div>
      </div>

      {/* Features Section */}
      <section className="py-0 px-6 lg:px-16 bg-primary">
        <h2 className="text-3xl font-bold text-green-300 mb-8 text-center lg:text-left">FEATURES</h2>

        <div className="grid grid-cols-1 md:grid-cols-2 gap-6 lg:gap-8">
          
          {/* Interactive Lessons */}
          <div className="card w-full bg-card card-sm shadow-sm border border-secondary">
            <div className="card-body">
              <h2 className="card-title flex text-primary flex-col items-center justify-center text-center">
                <FontAwesomeIcon icon={faGraduationCap} />
                <span className="text-xl">Interactive Lessons</span>
              </h2>
              <p className="text-primary">Engage with lessons designed to build your language skills through interactive activities.</p>
            </div>
          </div>

          {/* Vocabulary Practice */}
          <div className="card w-full bg-card card-sm shadow-sm border border-secondary ">
            <div className="card-body">
            <h2 className="card-title flex text-primary flex-col items-center justify-center text-center">
              <FontAwesomeIcon className="text-primary" icon={faLanguage} />
              <span className="text-xl">Vocabulary Practice</span>
            </h2>
            <p className="text-primary">Enhance your vocabulary with daily practice and quizzes tailored to your level.</p>
            </div>
          </div>

          {/* AI Chat */}
          <div className="card w-full bg-card card-sm shadow-sm border border-secondary">
            <div className="card-body">
              <h2 className="card-title text-primary flex flex-col items-center justify-center text-center">
                <FontAwesomeIcon icon={faComments} />
                <span className="text-xl">AI Chat</span>
              </h2>
              <p className="text-primary">Chat with AI to improve your conversation skills and get instant feedback.</p>
            </div>
          </div>

          {/* Study Materials */}
          <div className="card w-full bg-card card-sm shadow-sm border border-secondary">
            <div className="card-body">
              <h2 className="card-title flex text-primary flex-col items-center justify-center text-center">
                <FontAwesomeIcon icon={faBookOpenReader} />
                <span className="text-xl">Study Materials</span>
              </h2>
              <p className="text-primary">Access a wide range of study materials to support your learning journey.</p>
            </div>
          </div>

        </div>

        {/* ADD CTA Buttons */}
      </section>

      {/* About Section */}
      <section>
      <div className="bg-primary py-16 px-6 lg:px-16">
          <h2 className="text-3xl font-bold text-green-300 mb-4">ABOUT</h2>
          <p className="text-lg text-text">
          Manabu is a free and easy-to-use platform designed to help learners practice Japanese effortlessly. Whether you're a complete beginner or looking to sharpen your skills, Manabu provides interactive lessons, vocabulary exercises, and AI-powered conversations to make learning engaging and effective.
          This website is more than just a learning tool—it's also a personal passion project. Built solo, Manabu is a labor of love aimed at making Japanese accessible to anyone interested. I truly appreciate anyone who takes the time to check it out, and I hope it helps you on your language-learning journey!
          </p>
        </div>
      </section>

       {/* Footer Section */}
       <footer className="bg-gray-100 text-black py-8 px-6 lg:px-16 flex flex-col md:flex-row justify-between items-center">
        <div>
          <h2 className="text-xl font-bold">Manabu</h2>
          <ul className="text-sm mt-2 space-y-1">
            <li><a href="#">About Us</a></li>
            <li><a href="#">Privacy Policy</a></li>
            <li><a href="#">Terms of Service</a></li>
          </ul>
        </div>
       {/* <div className="flex space-x-4">
          <a href="#" className="text-black">Facebook</a>
          <a href="#" className="text-black">Twitter</a>
          <a href="#" className="text-black">Instagram</a>
        </div>
        <div>
          <ul className="text-sm mt-2 space-y-1">
            <li><a href="#">Contact</a></li>
          </ul>
        </div>*/}
      </footer>
    </div>
  );
};

export default LandingPage;
