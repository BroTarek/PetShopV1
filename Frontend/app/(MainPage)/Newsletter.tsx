import React from 'react'

const Newsletter = () => {
  return (
    
        <section className="px-6 md:px-12 py-32 max-w-screen-xl mx-auto text-center">
            <div className="bg-primary text-on-primary p-12 md:p-24 rounded-lg relative overflow-hidden">
                <div
                    className="absolute top-0 right-0 w-64 h-64 bg-secondary/10 rounded-full blur-3xl -z-10 translate-x-1/2 -translate-y-1/2">
                </div>
                <h2 className="text-3xl md:text-5xl font-extrabold tracking-tight mb-6">Join our Inner Circle</h2>
                <p className="text-on-primary-container max-w-xl mx-auto mb-12 text-lg">Receive exclusive access to new
                    arrivals, curated pet care tips, and community events.</p>
                <form className="max-w-md mx-auto flex flex-col md:flex-row gap-4">
                    <input
                        className="flex-1 px-6 py-4 rounded-xl bg-surface-container-low text-primary border-none focus:ring-2 focus:ring-secondary-fixed text-sm"
                        placeholder="Email address" type="email" />
                    <button
                        className="px-8 py-4 bg-secondary-fixed text-on-secondary-fixed rounded-xl font-bold hover:bg-secondary-container transition-colors">Subscribe</button>
                </form>
            </div>
        </section>
  )
}

export default Newsletter