import React from 'react'

const CreatePostAnchor = () => {
  return (
    <>
     <div
                className="bg-surface-container-lowest rounded-lg p-6 flex items-center gap-4 shadow-[0_20px_40px_rgba(27,27,31,0.06)]">
                <div className="w-10 h-10 rounded-full overflow-hidden flex-shrink-0">
                    <img data-alt="Avatar of user"
                        src="https://lh3.googleusercontent.com/aida-public/AB6AXuAJZwMAKsCpHzvj62vON85xpnK3ScGUFn31wxKV37yyY-XF9_3ukdweBw5PF85GIa_WF955uhZ-Ift7qzSkIW09PrmXamz-BBjYc27WY_XjHKaGD9va11JFwke3Uei3K_XtXW9WyToIYOEljI6W9hTu_3qMjABAD-PaVu0jWYmWsCYYJP-s53eIq8aH0ib1C8GuzZEGMkbM6Lwt-UYN3m0sAN73lpMqgj6dT93q0gSgHbG9gFCPPHegDwFkZC6RIcxkAzYRiWPUmC8" />
                </div>
                <button
                    className="w-full text-left px-6 py-3 bg-surface-container-low rounded-full text-on-surface-variant hover:bg-surface-container transition-colors">
                    Share a moment from your companion's day...
                </button>
            </div>
    </>
  )
}

export default CreatePostAnchor