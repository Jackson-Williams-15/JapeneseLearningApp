import React from "react";
import Logo from '../assets/Print_Transparent.svg?react';

const NavBar = () => {
  return (
    <div className="navbar h-16 bg-base-100 px-3">
      {/* Left section: Logo & Nav Links */}
      <div className="flex flex-1 items-center space-x-2">
        {/* SVG Logo */}
        <a href="/" className="flex items-center">
        <Logo className="h-30 w-40" />
        </a>

        {/* Navigation Links */}
        <div className="hidden md:flex items-center">
          <button className="btn text-lg btn-ghost">Chat</button>
          <button className="btn text-lg btn-ghost">Vocabulary</button>
          <button className="btn text-lg btn-ghost">Writing</button>
          <button className="btn text-lg btn-ghost">Resources</button>
        </div>
      </div>

      {/* Right section: Auth Buttons */}
      <div className="flex items-center space-x-3">
        <button className="btn btn-ghost btn-sm px-4 py-1">Log in</button>
        <button className="btn btn-primary btn-sm !text-white border-primary px-4 py-1 rounded-full w-auto">
          Sign up
        </button>
      </div>
    </div>
  );
};

export default NavBar;