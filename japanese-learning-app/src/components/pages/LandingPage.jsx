import React from "react";
import NavBar from "../NavBar";
import TowerImg from "../TowerImg";
import CherryImg from "../CherryImg";

const LandingPage = () => {
  return (
    <div className="bg-[#2D1B3D] min-h-screen text-white">
      <NavBar />

      {/* Hero Section */}
      <div className="hero min-h-screen bg-primary">
        <div className="hero-content flex-col lg:flex-row-reverse">

          {/* Text Content */}
          <div className="text-center lg:text-left">
            <h1 className="text-5xl font-bold">Learn Japanese Effortlessly</h1>
            <p className="py-6 text-lg text-gray-300">
              Dive into the world of Japanese language and culture with interactive lessons and engaging content.
            </p>
            <button className="btn btn-wide btn-secondary text-lg">Get Started</button>
          </div>
          {/* Image Section */}
          <div className="lg:w-1/2 flex flex-row justify-center items-center space-x-4 mt-8 lg:mt-0">
            {/* Replace with your own image paths or imports */}
            <TowerImg />
            <CherryImg />
          </div>
        </div>
      </div>
    </div>
  );
};

export default LandingPage;
