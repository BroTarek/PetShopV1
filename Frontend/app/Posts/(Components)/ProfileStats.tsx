import React from 'react'

const ProfileStats = () => {
  return (
    <>
      <aside className="hidden md:block md:col-span-3 space-y-6">
            <div
                className="bg-surface-container-lowest rounded-lg p-8 shadow-editorial-shadow sticky top-32">
                <div className="flex flex-col items-center text-center">
                    <div
                        className="w-24 h-24 rounded-full overflow-hidden mb-4 p-1 bg-gradient-to-tr from-secondary-fixed to-primary">
                        <img className="rounded-full w-full h-full object-cover"
                            data-alt="Portrait of a male pet enthusiast smiling, warm natural lighting, soft background"
                            src="https://lh3.googleusercontent.com/aida-public/AB6AXuBe8HmI6sav4zq2NN5muoDRv8Uc1YvQXHl4NTazgqlQYRU3t-M6RxJxmokWYpkylqClfEExw78SJ2QPqpq4oef_CYY6PUvZBwKr23qpVrKenmEFRYXrtlghFAL2fyFdZiLFrI6eNhBndAZbnmixnO8Q8GbgRYhRV9VfJd6mi3rym_O9_7nu6rgcAV5ZsqipVMdPNz1CvaEJctDxaccO4aPMQFhxYLold_KdtlT87w7kyDKwkrqbSo9nNm_0-IjVJdzz1POckCaeLfE" />
                    </div>
                    <h2 className="font-headline font-extrabold text-xl text-primary">Julian Thorne</h2>
                    <p className="text-sm text-on-surface-variant mb-6">Canine Specialist &amp; Storyteller</p>
                    <div className="w-full space-y-4 text-left border-t border-surface-container pt-6">
                        <div className="flex justify-between items-center">
                            <span
                                className="text-xs font-semibold text-on-surface-variant uppercase tracking-wider">Followers</span>
                            <span className="font-bold text-primary">1,248</span>
                        </div>
                        <div className="flex justify-between items-center">
                            <span
                                className="text-xs font-semibold text-on-surface-variant uppercase tracking-wider">Favorites</span>
                            <span className="font-bold text-primary">82</span>
                        </div>
                    </div>
                    <button
                        className="mt-8 w-full py-3 bg-primary text-on-primary rounded-xl font-bold tracking-tight scale-95 active:opacity-80 transition-all hover:bg-primary-container">
                        My Dashboard
                    </button>
                </div>
            </div>
        </aside>
    </>
  )
}

export default ProfileStats